package me.denisblondeel.ma.server.Domain;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public int id;

    private String email;

    private String Password;

    private String ConfirmPassword;

    public User(String email, String Password, String ConfirmPassword) {
        setEmail(email);
        setPassword(Password);
        setConfirmPassword(ConfirmPassword);
    }

    public User()
    {

    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setPassword(String password) {
        this.Password = password;
    }

    public String getEmail() {
        return email;
    }

    public String getPassword()
    {
        return Password;
    }

    public void setConfirmPassword(String ConfirmPassword){this.ConfirmPassword = ConfirmPassword;}

    public String getConfirmPassword()
    {
        return ConfirmPassword;
    }

    public boolean isEqual(User user)
    {
        if (this.email.equals(user.getEmail()) && this.Password.equals(user.getPassword())) return true;
        else return false;
    }
}
