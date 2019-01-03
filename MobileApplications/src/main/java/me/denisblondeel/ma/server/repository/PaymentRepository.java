package me.denisblondeel.ma.server.repository;

import me.denisblondeel.ma.server.Domain.Payment;
import me.denisblondeel.ma.server.Domain.User;
import org.springframework.data.repository.CrudRepository;

import java.util.List;
import java.util.UUID;
public interface PaymentRepository extends CrudRepository<Payment, Integer>
{
    public Iterable<Payment> findAllByUser(String user);
}
