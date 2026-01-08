
let slidets = document.querySelectorAll(".hero-slider img");
let indexes = 0;

function showSlide(i) {
    slidets.forEach(slide => slide.classList.remove("active"));
    slidets[i].classList.add("active");
}

document.querySelector(".next").onclick = () => {
    indexes = (indexes + 1) % slidets.length;
    showSlide(indexes);
};

document.querySelector(".prev").onclick = () => {
    indexes = (indexes - 1 + slidets.length) % slidets.length;
    showSlide(indexes);
};

setInterval(() => {
    indexes = (indexes + 1) % slidets.length;
    showSlide(indexes);
}, 5000);


// Navbar shadow on scroll
window.addEventListener("scroll", () => {
    const navbar = document.getElementById("navbar");
    if (window.scrollY > 50) {
        navbar.style.boxShadow = "0 4px 12px rgba(0,0,0,0.2)";
    } else {
        navbar.style.boxShadow = "0 2px 10px rgba(0,0,0,0.1)";
    }
});
const track = document.querySelector(".carousel-track");
const slides = document.querySelectorAll(".carousel-item");
const prevBtn = document.querySelector(".carousel-btn.prev");
const nextBtn = document.querySelector(".carousel-btn.next");

let index = 0;
let autoSlide;

/* Update Slide */
function updateCarousel() {
    track.style.transform = `translateX(-${index * 100}%)`;
}

/* Next */
function nextSlide() {
    index = (index + 1) % slides.length;
    updateCarousel();
}

/* Prev */
function prevSlide() {
    index = (index - 1 + slides.length) % slides.length;
    updateCarousel();
}

/* Auto Slide */
function startAutoSlide() {
    autoSlide = setInterval(nextSlide, 3000);
}

/* Stop Auto on Interaction */
function resetAutoSlide() {
    clearInterval(autoSlide);
    startAutoSlide();
}

/* Event Listeners */
nextBtn.addEventListener("click", () => {
    nextSlide();
    resetAutoSlide();
});

prevBtn.addEventListener("click", () => {
    prevSlide();
    resetAutoSlide();
});

/* Start */
startAutoSlide();

const counters = document.querySelectorAll(".count");

const speed = 200;

const startCount = () => {
    counters.forEach(counter => {
        const updateCount = () => {
            const target = +counter.getAttribute("data-target");
            const count = +counter.innerText;

            const increment = Math.ceil(target / speed);

            if (count < target) {
                counter.innerText = count + increment;
                setTimeout(updateCount, 20);
            } else {
                counter.innerText = target;
            }
        };
        updateCount();
    });
};

/* Trigger when visible */
let triggered = false;
window.addEventListener("scroll", () => {
    const section = document.querySelector(".trust-stats");
    const sectionTop = section.getBoundingClientRect().top;

    if (sectionTop < window.innerHeight && !triggered) {
        startCount();
        triggered = true;
    }
});

const featureCards = document.querySelectorAll(".feature-card");

function revealFeatures() {
    const triggerBottom = window.innerHeight * 0.85;

    featureCards.forEach(card => {
        const cardTop = card.getBoundingClientRect().top;

        if (cardTop < triggerBottom) {
            card.style.opacity = "1";
            card.style.transform = "translateY(0)";
        }
    });
}

/* Initial State */
featureCards.forEach(card => {
    card.style.opacity = "0";
    card.style.transform = "translateY(30px)";
    card.style.transition = "all 0.6s ease";
});

window.addEventListener("scroll", revealFeatures);
revealFeatures();

const testimonialTrack = document.querySelector(".testimonial-track");
const testimonialSlides = document.querySelectorAll(".testimonial-card");

let testimonialIndex = 0;

function moveTestimonial() {
    testimonialIndex++;
    if (testimonialIndex >= testimonialSlides.length) {
        testimonialIndex = 0;
    }
    testimonialTrack.style.transform =
        `translateX(-${testimonialIndex * 100}%)`;
}

// Change testimonial every 4 seconds
setInterval(moveTestimonial, 4000);

const faqQuestions = document.querySelectorAll(".faq-question");

faqQuestions.forEach(question => {
    question.addEventListener("click", () => {
        const answer = question.nextElementSibling;
        const icon = question.querySelector("span");

        // Close others
        document.querySelectorAll(".faq-answer").forEach(a => {
            if (a !== answer) {
                a.style.maxHeight = null;
                a.previousElementSibling.querySelector("span").textContent = "+";
            }
        });

        // Toggle current
        if (answer.style.maxHeight) {
            answer.style.maxHeight = null;
            icon.textContent = "+";
        } else {
            answer.style.maxHeight = answer.scrollHeight + "px";
            icon.textContent = "−"; ``
        }
    });
});

document.querySelector(".back-to-top").addEventListener("click", function (e) {
    e.preventDefault();
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});

//hero section crousel
const slidess = document.querySelector('.slides');
let indexs = 0;

setInterval(() => {
    index = (index + 1) % 3;
    slidess.style.transform = `translateX(-${index * 100}%)`;
}, 3000);

