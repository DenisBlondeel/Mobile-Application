package me.denisblondeel.ma.server.Controller;
import java.util.List;
import java.util.UUID;

import me.denisblondeel.ma.server.Domain.Payment;
import me.denisblondeel.ma.server.Service.PaymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


@RestController
public class Controller {

    private PaymentService service;

    public Controller(PaymentService service)
    {
        this.service = service;
        System.out.println("yolo in da house bruh");

    }

    @CrossOrigin
    @RequestMapping("/payment")
    public List<Payment> payments() {
        return service.getAll();
    }

    @CrossOrigin
    @RequestMapping("/payment/{id}")
    public Payment getPayment(@PathVariable UUID id)
    {
        return service.getPayment(id);
    }

    @CrossOrigin
    @RequestMapping(method = RequestMethod.POST, value = "/payment")
    public Payment addPayment(@RequestBody Payment payment)
    {
        service.addPayment(payment);
        return payment;
    }

    @CrossOrigin
    @RequestMapping(method = RequestMethod.PUT, value = "/payment/{id}")
    public Payment updatePayment(@RequestBody Payment payment, @PathVariable UUID id)
    {
        service.updatePayment(id, payment);
        return payment;
    }
}