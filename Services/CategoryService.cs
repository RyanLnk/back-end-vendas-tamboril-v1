using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Dtos.Category;
using VendasTamboril.Models;

namespace VendasTamboril.Services;

public class CategoryService
{
  private readonly TamborilContext _context;

  public CategoryService([FromServices] TamborilContext context)
  {
    _context = context;
  }

  public List<CategoryResponseDto> GetCategories()
  {
    return _context.Categories.AsNoTracking().ProjectToType<CategoryResponseDto>().ToList();
  }

  public CategoryResponseDto GetCategory(int id)
  {
    var category = _context.Categories.AsNoTracking().SingleOrDefault(c => c.Id == id);

    if (category is null)
      return null;

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }

  public CategoryResponseDto PostCategory(CategoryCreateUpdateDto categoryDto)
  {
    var category = categoryDto.Adapt<Category>();

    var dateNow = DateTime.Now;
    category.CreationDate = dateNow;
    category.UpdateDate = dateNow;

    _context.Categories.Add(category);
    _context.SaveChanges();

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }

  public CategoryResponseDto PutCategory(int id, CategoryCreateUpdateDto categoryDto)
  {
    var category = _context.Categories.SingleOrDefault(c => c.Id == id);

    if (category is null)
      return null;

    categoryDto.Adapt(category);

    category.UpdateDate = DateTime.Now;
    _context.SaveChanges();

    var categoryResponse = category.Adapt<CategoryResponseDto>();

    return categoryResponse;
  }

  public void DeleteCategory(int id)
  {
    var category = _context.Categories.SingleOrDefault(c => c.Id == id);

    if (category is null)
      throw new Exception("Category not found");

    _context.Remove(category);
    _context.SaveChanges();
  }
}
