$(document).ready(function () {
    const dataTable = $('#usersTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
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
                        url: '/Admin/User/GetAllUsers/',
                        contentType: "application/json",
                        beforeSend: function () {
                            //$('#usersTable').hide();
                            /*$('.spinner-border').show();*/
                        },
                        success: function (data) {
                            const userListDto = jQuery.parseJSON(data);
                            /*dataTable.clear();*/
                            console.log(userListDto);
                            if (userListDto.ResultStatus === 0) {
                                $.each(userListDto.Users.$values, function (index, user) {
                                    dataTable.row.add([
                                        user.Id,
                                        user.UserName,
                                        user.Email,
                                        user.PhoneNumber,
                                        `<img src="/img/${user.Picture}" alt="${user.UserName}" style="max-height:50px; max-width:50px;" />`
                                            `
									<button class="btn btn-primary btn-sm btn-update" data-id="${user.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
									<button class="btn btn-danger btn-sm btn-delete" data-id="${user.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
							`
                                    ]);
                                });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#usersTable').fadeIn(1400);
                            }
                            else {
                                toastr.error(`${userListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#usersTable').fadeIn(1000);
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
        const url = '/Admin/User/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });
        placeHolderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-user-add');
            const actionUrl = form.attr('action'); //formun hangi action'a post edildiğini aldık.
            const dataToSend = new FormData(form.get(0)); //formdaki verileri aldık. IFormfile tipinden ötürü değişkliğe gidildi. bu verinin controller'a gitmemesi.
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType: false,
                success: function (data) {
                    const userAddAjaxModel = jQuery.parseJSON(data);
                    const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        dataTable.row.add([
                            userAddAjaxModel.UserDto.User.Id,
                            userAddAjaxModel.UserDto.User.UserName,
                            userAddAjaxModel.UserDto.User.Email,
                            userAddAjaxModel.UserDto.User.PhoneNumber,
                            `<img src="/img/${userAddAjaxModel.UserDto.User.Picture}" alt="${userAddAjaxModel.UserDto.User.UserName}" style="max-height:50px; max-width:50px;" />`
                             `
									<button class="btn btn-primary btn-sm btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
									<button class="btn btn-danger btn-sm btn-delete" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
							`
                        ]).draw();
                        toastr.success(`${userAddAjaxModel.UserDto.Message}`, 'Başarılı İşlem!');
                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });
    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const userName = tableRow.find('td:eq(1)').text();
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Silmek istediğinize emin misiniz?',
            text: `${userName} adlı kullanıcı silinecektir!`,
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
                    data: { userId: id },
                    url: '/Admin/User/Delete/',
                    success: function (data) {
                        const userDto = jQuery.parseJSON(data);
                        if (userDto.ResultStatus === 0) {//backend tarafında hata oluşmuş olabilir.
                            swalWithBootstrapButtons.fire(
                                'Silindi!',
                                `${userDto.User.UserName} adlı kullanıcı başarıyla silinmiştir.`,
                                'success'
                            );
                            dataTable.row(tableRow).remove().draw();
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız İşlem!',
                                text: `${userDto.Message}`,
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
        const url = '/Admin/User/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { userId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("Bir hata oluştu.");
            });
        });

        /*Ajax Post User Update*/

        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-user-update');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0)); //formdaki verileri aldık. IFormfile tipinden ötürü değişkliğe gidildi. bu verinin controller'a gitmemesi.
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType: false,
                success: function (data) {
                    let userUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(userUpdateAjaxModel);
                    let id;
                    let tableRow;
                    if (userUpdateAjaxModel.UserDto !== null) {
                        id = userUpdateAjaxModel.UserDto.User.Id;
                        tableRow = $(`[name="${id}"]`);
                    }                   
                    const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        dataTable.row(tableRow).data([
                            userUpdateAjaxModel.UserDto.User.Id,
                            userUpdateAjaxModel.UserDto.User.UserName,
                            userUpdateAjaxModel.UserDto.User.Email,
                            userUpdateAjaxModel.UserDto.User.PhoneNumber,
                            `<img src="/img/${userUpdateAjaxModel.UserDto.User.Picture}" alt="${userUpdateAjaxModel.UserDto.User.UserName}" class="my-image-table" />`
                                `
									<button class="btn btn-primary btn-sm btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-edit"></span>Düzenle</button>
									<button class="btn btn-danger btn-sm btn-delete" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
							`
                        ]);
                        tableRow.attr("name", `${id}`);
                        dataTable.row(tableRow).invalidate();
                        toastr.success(`${userUpdateAjaxModel.UserDto.Message}`, "Başarılı İşlem!");
                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });
});