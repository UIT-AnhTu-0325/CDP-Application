package com.marketing.realtimemarketingservice;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class RealtimeMarketingServiceApplication {

	public static void main(String[] args) {
		SpringApplication.run(RealtimeMarketingServiceApplication.class, args);
	}

/* 	@Bean
	public Bot alice() {
		return new Bot(BotConfiguration.builder()
				.name("chatbot")
				.path("src/main/resources")
				.build());
	} */
}
