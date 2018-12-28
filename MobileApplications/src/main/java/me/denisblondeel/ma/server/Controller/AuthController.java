package me.denisblondeel.ma.server.Controller;
import me.denisblondeel.ma.server.Domain.User;
import me.denisblondeel.ma.server.Service.AuthService;
import org.springframework.web.bind.annotation.*;


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
        User dbUser = service.getUser(user.getUsername());
        if( dbUser.equals(user))
        {
            return user;
        }
        else return null;
    }
}