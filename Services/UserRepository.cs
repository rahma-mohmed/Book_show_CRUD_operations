using TaskIT.Models;

namespace TaskIT.Services
{
    public class UserRepository
    {
        ProgContext context = new ProgContext();

        public List<User> getAll()
        {
            return context.Users.ToList();
        }
        public User getById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Create(User user)
        {
            context.Users.Add(user);
            int raw = context.SaveChanges();
            return raw;
        }

        public int Update(int id, User user)
        {
            User oldUser = context.Users.FirstOrDefault(x => x.Id == id);
            oldUser.Name = user.Name;
            oldUser.Password = user.Password;
            oldUser.Email = user.Email;
            oldUser.Id = user.Id;
            int raw = context.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            User oldUser = context.Users.FirstOrDefault(x => x.Id == id);
            context.Users.Remove(oldUser);
            int raw = context.SaveChanges();
            return raw;
        }

        public User getByName(string name)
        {
            return context.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}

