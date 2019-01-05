package me.denisblondeel.ma.server.Service;


import me.denisblondeel.ma.server.Domain.User;
import me.denisblondeel.ma.server.repository.UserRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

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

    public User getUser(String email)
    {
        System.out.println(email);
        return repository.findByEmail(email);
    }

    public List<User> getAll()
    {
        List<User> users = new ArrayList<>();
        repository.findAll().forEach(users::add);
        return users;
    }


}
