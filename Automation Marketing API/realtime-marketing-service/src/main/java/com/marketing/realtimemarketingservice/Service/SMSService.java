package com.marketing.realtimemarketingservice.Service;

import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;

import org.springframework.stereotype.Service;

@Service
public class SMSService {
        private final String ACCOUNT_SID ="";

	    private final String AUTH_TOKEN = "";

	    private final String FROM_NUMBER = "";

	    public void send(String to, String content) {
	    	Twilio.init(ACCOUNT_SID, AUTH_TOKEN);

	        Message message = Message.creator(new PhoneNumber(to), new PhoneNumber(FROM_NUMBER), content)
	                .create();
	    }
}
