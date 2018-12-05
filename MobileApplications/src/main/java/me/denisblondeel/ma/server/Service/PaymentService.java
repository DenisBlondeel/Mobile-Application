package me.denisblondeel.ma.server.Service;

import me.denisblondeel.ma.server.Domain.Payment;
import me.denisblondeel.ma.server.repository.PaymentRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

@Service
public class PaymentService {

    private PaymentRepository repository;

    public PaymentService(PaymentRepository repository)
    {
        this.repository = repository;
    }

    public List<Payment> getAll()
    {
        List<Payment> payments = new ArrayList<>();
        repository.findAll().forEach(payments::add);
        return payments;
    }


    public Payment getPayment(UUID id)
    {
        return repository.findById(id).get();
    }

    public void addPayment(Payment payment)
    {
        repository.save(payment);
    }

    public void updatePayment(UUID id, Payment payment)
    {
        repository.deleteById(id);
        Payment pay = payment;
        pay.setId(id);
        repository.save(pay);
    }
}
