using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using shared.Model;

namespace Service;

public class DataService
{
    private Context db { get; }

    public DataService(Context db) {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData() {
        
        Post post = db.Posts.FirstOrDefault()!;
        if (post == null) {
            post = new Post { Title = "Kristian", Date = "000", Content = "hej ", Username = "busdriver08" };
            db.Posts.Add(post);
            db.Posts.Add(new Post { Title = "Kristian", Date = "000", Content = "hej ", Username = "busdriver08" });
            db.Posts.Add(new Post { Title = "Kristian", Date = "000", Content = "hej ", Username = "busdriver08" });
        }

        Comment comment = db.Comments.FirstOrDefault()!;
        if (comment == null)
        {
            db.Comments.Add(new Comment { Username = "busdriver87", Text = "Harry Potter", Post = post });
            db.Comments.Add(new Comment { Username = "busdriver87", Text = "Harry Potter", Post = post });
            db.Comments.Add(new Comment { Username = "busdriver87", Text = "Harry Potter", Post = post });
        }

        db.SaveChanges();
    }

    public List<Comment> GetComments() {
        return db.Comments.Include(c => c.Post).ToList();
    }

    public Comment GetComment(int id) {
        return db.Comments.Include(c => c.Post).FirstOrDefault(c => c.CommentId == id);
    }

    public List<Post> GetPosts() {
        return db.Posts.ToList();
    }

    public Post GetPost(int id) {
        return db.Posts.Include(p => p.Comments).FirstOrDefault(p => p.PostId == id);
    }

    public string CreateComment(string username, string text, int postId) {
        Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);
        db.Comments.Add(new Comment { Username = username, Text = text, Post = post });
        db.SaveChanges();
        return "Comment created";
    }

   
}