namespace EfTask.Models
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public string Title { set; get; } = "";
        public string Content { set; get; } = "";
        public virtual ICollection<Comment> Comments { get; set; }  
        
    }
}
