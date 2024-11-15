// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

console.log("JavaScript-filen fungerar");

document.addEventListener('DOMContentLoaded', function () {
    // Prenumerationsformulär
    const newsletterForm = document.getElementById("newsletter-form");
    if (newsletterForm) {
        newsletterForm.addEventListener("submit", function(event) {
            console.log("Formuläret skickas");
            event.preventDefault();

            var emailInput = document.getElementById("email");
            var emailValue = emailInput.value;
            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

            if (!emailPattern.test(emailValue)) {
                alert("Please enter a valid email address.");
                emailInput.focus();
            } else {
                console.log("E-postadressen är giltig");
                alert("You are now a subscriber!");
            }
        });
    } else {
        console.error("Prenumerationsformuläret kunde inte hittas.");
    }

    // Kontaktformulär
    const contactForm = document.getElementById('contact-form');
    if (contactForm) {
        contactForm.addEventListener('submit', function(event) {
            event.preventDefault();
            console.log('Form submission prevented.');

            var isValid = true;

            document.getElementById('nameError').textContent = '';
            document.getElementById('emailError').textContent = '';
            document.getElementById('messageError').textContent = '';

            var name = document.getElementById('name').value;
            var email = document.getElementById('email').value;
            var message = document.getElementById('message').value;

            if (name.length < 2 || name.length > 50) {
                isValid = false;
                document.getElementById('nameError').textContent = 'Name must be between 2 and 50 characters long.';
                console.log('Name validation failed.');
            }

            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(email)) {
                isValid = false;
                document.getElementById('emailError').textContent = 'Please enter a valid email address.';
                console.log('Email validation failed.');
            }

            if (message.length < 10 || message.length > 500) {
                isValid = false;
                document.getElementById('messageError').textContent = 'Message must be between 10 and 500 characters long.';
                console.log('Message validation failed.');
            }

            if (isValid) {
                alert('Your message has been sent!');
                console.log('Form submitted successfully.');
                event.target.reset();
            } else {
                console.log('Form submission failed due to validation errors.');
            }
        });
    } else {
        console.error("Kontaktformuläret kunde inte hittas.");
    }

    // Inloggningsformulär
    const loginForm = document.querySelector('.login-email-pass');
    if (loginForm) {
        loginForm.addEventListener('submit', function(event) {
            let valid = true;

            // Få e-post och lösenord
            const email = document.getElementById('email').value;
            const password = document.getElementById('password').value;

            // Validera e-post
            if (!email) {
                alert("Email is required.");
                valid = false;
            } else if (!validateEmail(email)) {
                alert("Invalid email address.");
                valid = false;
            }

            // Validera lösenord
            if (!password) {
                alert("Password is required.");
                valid = false;
            }

            // Stoppa formuläret om ogiltigt
            if (!valid) {
                event.preventDefault();
            }
        });
    } else {
        console.error("Inloggningsformuläret kunde inte hittas.");
    }

    function validateEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(String(email).toLowerCase());
    }
});
