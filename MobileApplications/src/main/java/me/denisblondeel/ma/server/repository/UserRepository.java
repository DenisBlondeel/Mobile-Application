package me.denisblondeel.ma.server.repository;

import me.denisblondeel.ma.server.Domain.User;
import org.springframework.data.repository.CrudRepository;

public interface UserRepository extends CrudRepository<User, Integer> {

    public User findByEmail(String Email);
}
