package me.denisblondeel.ma.server.repository;

import me.denisblondeel.ma.server.Domain.Payment;
import org.springframework.data.repository.CrudRepository;

import java.util.UUID;

public interface PaymentRepository extends CrudRepository<Payment, UUID>
{
}
