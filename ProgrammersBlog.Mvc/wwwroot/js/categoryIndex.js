$(document).ready(function () {
	$('#categoriesTable').DataTable({
		dom:
			"<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
			"<'row'<'col-sm-12'tr>>" +
			"<'row'<'col-sm-5'i><'col-sm-7'p>>",
		"order": [[6,"desc"]],
		buttons: [
			{
				text: 'Ekle',
				attr: {
					id: "btnAdd",
				},
				className: 'btn btn-success',
				action: function (e, dt, node, config) {

				}
			},
			{
				text: 'Yenile',
				className: 'btn btn-warning',
				action: function (e, dt, node, config) {
					$.ajax({
						type: 'GET',
						url: '/Admin/Category/GetAllCategories/',
						contentType: "application/json",
						beforeSend: function () {
							$('#categoriesTable').hide();
							$('.spinner-border').show();
						},
						success: function (data) {
							const categoryListDto = jQuery.parseJSON(data);
							console.log(categoryListDto);
							if (categoryListDto.ResultStatus === 0) {
								let tableBody = "";
								$.each(categoryListDto.Categories.$values, function (index, category) {
									tableBody += `
																	<tr name=${category.Id}>
																		<td>${category.Id}</td>
																		<td>${category.Name}</td>
																		<td>${category.Description}</td>
																		<td>${category.IsActive ? "Evet":"Hayır"}</td>
																		<td>${category.IsDeleted ? "Evet" : "Hayır"}</td>
																		<td>${category.Note}</td>
																		<td>${convertToShortDate(category.CreatedDate)}</td>
																		<td>${category.CreatedByName}</td>
																		<td>${convertToShortDate(category.ModifiedDate)}</td>
																		<td>${category.ModifiedByName}</td>
																		<td>
											<button class="btn btn-primary btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
											<button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
										</td>
															</tr>`;
								});
								$('#categoriesTable > tbody').replaceWith(tableBody);
								$('.spinner-border').hide();
								$('#categoriesTable').fadeIn(1400);
							}
							else {
								toastr.error(`${categoryListDto.Message}`, 'İşlem Başarısız!');
							}
						},
						error: function (err) {
							console.log(err);
							$('.spinner-border').hide();
							$('#categoriesTable').fadeIn(1000);
							toastr.error(`${err.responseText}`, 'Hata!');
						}
					});
				}
			}
		],
		language: {
			"sDecimal": ",",
			"sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
			"sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
			"sInfoEmpty": "Kayıt yok",
			"sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
			"sInfoPostFix": "",
			"sInfoThousands": ".",
			"sLengthMenu": "Sayfada _MENU_ kayıt göster",
			"sLoadingRecords": "Yükleniyor...",
			"sProcessing": "İşleniyor...",
			"sSearch": "Ara:",
			"sZeroRecords": "Eşleşen kayıt bulunamadı",
			"oPaginate": {
				"sFirst": "İlk",
				"sLast": "Son",
				"sNext": "Sonraki",
				"sPrevious": "Önceki"
			},
			"oAria": {
				"sSortAscending": ": artan sütun sıralamasını aktifleştir",
				"sSortDescending": ": azalan sütun sıralamasını aktifleştir"
			},
			"select": {
				"rows": {
					"_": "%d kayıt seçildi",
					"0": "",
					"1": "1 kayıt seçildi"
				}
			}
		}
	});
	/* Datatables ends here */

	$(function () {
		const url = '/Admin/Category/Add/'
		const placeHolderDiv = $('#modalPlaceHolder');
		$('#btnAdd').click(function () {
			$.get(url).done(function (data) {
				placeHolderDiv.html(data);
				placeHolderDiv.find(".modal").modal('show');
			});
		});
		placeHolderDiv.on('click', '#btnSave', function (event) {
			event.preventDefault();
			const form = $('#form-category-add');
			const actionUrl = form.attr('action'); //formun hangi action'a post edildiğini aldık.
			const dataToSend = form.serialize(); //formdaki verileri aldık.
			$.post(actionUrl, dataToSend).done(function (data) {
				const categoryAddAjaxModel = jQuery.parseJSON(data);
				const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
				placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
				const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
				if (isValid) {
					placeHolderDiv.find('.modal').modal('hide');
					const newTableRow = `
													<tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
														<td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.IsActive ? "Evet" : "Hayır"}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.IsDeleted ? "Evet" : "Hayır"}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
														<td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
														<td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
														<td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
														<td>
															<button class="btn btn-primary btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
															<button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
														</td>
													</tr>`;
					const newTableRowObject = $(newTableRow);
					newTableRowObject.hide();
					$('#categoriesTable').append(newTableRowObject);
					newTableRowObject.fadeIn(3500);
					toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Başarılı İşlem!');
				}
				else {
					let summaryText = "";
					$('#validation-summary > ul > li').each(function () {
						let text = $(this).text();
						summaryText = `*${text}\n`;
					});
					toastr.warning(summaryText);
				}
			});
		});
	});
	$(document).on('click', '.btn-delete', function (event) {
		event.preventDefault();
		const id = $(this).attr('data-id');
		const tableRow = $(`[name="${id}"]`);
		const categoryName = tableRow.find('td:eq(1)').text();
		const swalWithBootstrapButtons = Swal.mixin({
			customClass: {
				confirmButton: 'btn btn-success',
				cancelButton: 'btn btn-danger'
			},
			buttonsStyling: false
		})

		swalWithBootstrapButtons.fire({
			title: 'Silmek istediğinize emin misiniz?',
			text: `${categoryName} adlı kategori silinecektir!`,
			icon: 'warning',
			showCancelButton: true,
			confirmButtonText: 'Evet, silmek istiyorum.',
			cancelButtonText: 'Hayır, silmek istemiyorum.',
			reverseButtons: true
		}).then((result) => {
			if (result.isConfirmed) {
				$.ajax({
					type: 'POST',
					dataType: 'json',
					data: { categoryId: id },
					url: '/Admin/Category/Delete/',
					success: function (data) {
						const categoryDto = jQuery.parseJSON(data);
						if (categoryDto.ResultStatus === 0) {//backend tarafında hata oluşmuş olabilir.
							swalWithBootstrapButtons.fire(
								'Silindi!',
								`${categoryDto.Category.Name} adlı kategori başarıyla silinmiştir.`,
								'success'
							);

							tableRow.fadeOut(3500);
						}
						else {
							Swal.fire({
								icon: 'error',
								title: 'Başarısız İşlem!',
								text: `${categoryDto.Message}`,
							})
						}
					},
					error: function (err) {
						console.log(err);
						toastr.error(`${err.responseText}`, "Hata!");
					}
				});
			} else if (
				result.dismiss === Swal.DismissReason.cancel
			) {
				swalWithBootstrapButtons.fire(
					'İptal edildi!',
					'Seçili kategori silinmedi :)',
					'error'
				);
			}
		});
	});
	$(function () {
		/*Ajax Get Category Update Modal Form*/
		const url = '/Admin/Category/Update/';
		const placeHolderDiv = $('#modalPlaceHolder');
		$(document).on('click', '.btn-update', function (event) {
			event.preventDefault();
			const id = $(this).attr('data-id');
			$.get(url, { categoryId: id }).done(function (data) {
				placeHolderDiv.html(data);
				placeHolderDiv.find('.modal').modal('show');
			}).fail(function () {
				toastr.error("Bir hata oluştu.");
            });
		});

		/*Ajax Post Category Update*/

		placeHolderDiv.on('click', '#btnUpdate', function (event) {
			event.preventDefault();
			const form = $('#form-category-update');
			const actionUrl = form.attr('action');
			const dataToSend = form.serialize();
			$.post(actionUrl, dataToSend).done(function (data) {
				const categoryUpdateAjaxModel = jQuery.parseJSON(data);
				console.log(categoryUpdateAjaxModel);
				const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
				placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
				const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
				if (isValid) {
					placeHolderDiv.find('.modal').modal('hide');
					const newTableRow = `
													<tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.Description}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.IsActive ? "Evet" : "Hayır"}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted ? "Evet" : "Hayır"}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
														<td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate)}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.CreatedByName}</td>
														<td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
														<td>${categoryUpdateAjaxModel.CategoryDto.Category.ModifiedByName}</td>
														<td>
															<button class="btn btn-primary btn-sm btn-update" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
															<button class="btn btn-danger btn-sm btn-delete" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
														</td>
													</tr>`;
					const newTableRowObject = $(newTableRow);
					const categoryTableRow = $(`[name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
					newTableRowObject.hide();
					categoryTableRow.replaceWith(newTableRowObject);
					newTableRowObject.fadeIn(3500);
					toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Başarılı İşlem!");
				}
				else {
					let summaryText = "";
					$('#validation-summary > ul > li').each(function () {
						let text = $(this).text();
						summaryText = `*${text}\n`;
					});
					toastr.warning(summaryText);
                }

			}).fail(function (response) {
				console.log(response);
            });
		});
	});
});