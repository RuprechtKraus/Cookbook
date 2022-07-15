namespace Cookbook.Models
{
    public class RecipeStep
    {
        public int RecipeStepID { get; set; }
        public int StepIndex { get; set; }
        public string Description { get; set; }
        
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}