
namespace Pratice
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            Category cat1 = new Category() { CategoryId = 1 , CategoryName = "Test1"};
            categories.Add(cat1);
            Category cat2 = new Category() { CategoryId = 2, CategoryName = "Test2" };
            categories.Add(cat1);

            return categories;
        }
    }
}
