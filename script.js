// script.js
const wheel = document.getElementById("wheel");
const spinBtn = document.getElementById("spin-btn");
const finalValue = document.getElementById("final-value");

// Your existing code...

// On page load, check if the wheel can be spun
document.addEventListener("DOMContentLoaded", () => {
  checkSpinAvailability();
});

// Check if the wheel can be spun
const checkSpinAvailability = () => {
  // Generate a random user ID (you might want to use a proper GUID generation library)
  const userId = generateRandomGuid();

  // Make a request to the backend to check if the wheel can be spun
  fetch("http://localhost:5000/checkSpinAvailability", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ userId }),
  })
    .then((response) => response.json())
    .then((data) => {
      if (data.canSpin) {
        spinBtn.disabled = false;
      } else {
        finalValue.innerHTML = `<p>The wheel may not be spun at the moment.</p>`;
      }
    })
    .catch((error) => console.error("Error checking spin availability:", error));
};

// Spin button click event
spinBtn.addEventListener("click", () => {
  spinBtn.disabled = true;
  finalValue.innerHTML = `<p>Good Luck!</p>`;

  // Make a request to the backend to spin the wheel
  fetch("http://localhost:5000/spinWheel", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      userId: generateRandomGuid(),
    }),
  })
    .then((response) => response.json())
    .then((data) => {
      // Assuming the backend returns the random angle to stop at
      let randomDegree = data.angle;
      // ... (existing code)
    })
    .catch((error) => console.error("Error spinning the wheel:", error));
});

// Function to generate a random GUID
const generateRandomGuid = () => {
  return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, (c) => {
    const r = (Math.random() * 16) | 0;
    const v = c === "x" ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
};
