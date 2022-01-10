package com.marketing.inboundedmarketingservice.Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/facebook")
public class FacebookController {
    
    @GetMapping
    public String test(){
        return "Thành công";
    }
}
