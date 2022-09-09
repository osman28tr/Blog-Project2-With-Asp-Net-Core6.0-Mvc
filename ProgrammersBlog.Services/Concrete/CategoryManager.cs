using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori başarı ile eklenmiştir.", new CategoryDto
            {
                Category = addedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{categoryAddDto.Name} adlı kategori başarı ile eklenmiştir."
            });
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;

                var deletedCategory = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, $"{deletedCategory.Name} adlı kategori başarı ile silinmiştir.",
                    new CategoryDto { Category = deletedCategory, ResultStatus = ResultStatus.Success, Message = $"{deletedCategory.Name} adlı kategori başarı ile silinmiştir." });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, $"Böyle bir kategori bulunamadı",
                    new CategoryDto { Category = null, ResultStatus = ResultStatus.Error, Message = $"Böyle bir kategori bulunamadı" });
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId, y => y.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto { Category = category, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", new CategoryDto
            {
                Category = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kategori bulunamadı"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir kategori bulunamadı"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted, y => y.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir kategori bulunamadı"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted && x.IsActive, y => y.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarı ile veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarı ile güncellenmiştir.",
                new CategoryDto { Category = updatedCategory, ResultStatus = ResultStatus.Success, Message = $"{categoryUpdateDto.Name} adlı kategori başarı ile güncellenmiştir." });
        }
    }
}
