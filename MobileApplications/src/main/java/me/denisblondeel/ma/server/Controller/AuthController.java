package me.denisblondeel.ma.server.Controller;
import me.denisblondeel.ma.server.Domain.User;
import me.denisblondeel.ma.server.Service.AuthService;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/auth")
public class AuthController {

    private AuthService service;

    public AuthController(AuthService service)
    {
        this.service = service;
        System.out.println("yolo in da house bruh");

    }

    @CrossOrigin
    @RequestMapping(method = RequestMethod.POST, value = "/register")
    public void register(@RequestBody User user)
    {
       service.addUser(user);
    }

    @CrossOrigin
    @RequestMapping(method = RequestMethod.POST, value = "/login")
    public User login(@RequestBody User user)
    {
        System.out.println("Request user : " + user);
        User dbUser = new User();
        System.out.println("testUser: " + dbUser);
        try
        {
            dbUser = service.getUser(user.getEmail());
            System.out.println("testUser: " + dbUser);
        }
        catch(Exception e)
        {
            System.out.println(e.getStackTrace());
        }

        if( dbUser != null && dbUser.getEmail().equals(user.getEmail()) && dbUser.getPassword().equals(user.getPassword())) {
            System.out.println("Request user : " + user);
            return user;
        }
        else return new User();
    }

    @CrossOrigin
    @RequestMapping(value = "/debug")
    public List<User> payments() {
        return service.getAll();
    }
}