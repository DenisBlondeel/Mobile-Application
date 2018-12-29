package me.denisblondeel.ma.server.Service;


import me.denisblondeel.ma.server.Domain.User;
import me.denisblondeel.ma.server.repository.UserRepository;
import org.springframework.stereotype.Service;

@Service
public class AuthService {

    private UserRepository repository;

    public AuthService(UserRepository repository)
    {
        this.repository = repository;
    }


    public void addUser(User user)
    {
        repository.save(user);
    }

    public User getUser(String username)
    {
        return repository.findById(username).get();
    }


}
