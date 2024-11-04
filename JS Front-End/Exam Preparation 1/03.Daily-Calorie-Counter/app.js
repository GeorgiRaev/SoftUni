document.addEventListener('DOMContentLoaded', function () {
    const loadMealsBtn = document.getElementById('loadMealsBtn');
    const addMealBtn = document.getElementById('addMealBtn');
    const editMealBtn = document.getElementById('editMealBtn');
    const deleteMealBtn = document.getElementById('deleteMealBtn');
    const mealList = document.getElementById('list');
    const foodInput = document.getElementById('food');
    const timeInput = document.getElementById('time');
    const caloriesInput = document.getElementById('calories');

    // Function to send GET request to load meals
    function loadMeals() {
        fetch('http://localhost:3030/jsonstore/tasks/')
            .then(response => response.json())
            .then(data => {
                mealList.innerHTML = ''; // Clear meal list
                Object.values(data).forEach(meal => {
                    const mealDiv = document.createElement('div');
                    mealDiv.classList.add('meal');
                    mealDiv.innerHTML = `
                        <h2>${meal.food}</h2>
                        <h3>${meal.time}</h3>
                        <h3>${meal.calories}</h3>
                        <div id="meal-buttons">
                            <button class="change-meal">Change</button>
                            <button class="delete-meal">Delete</button>
                        </div>`;
                    mealList.appendChild(mealDiv);
                });
            });
    }

    // Function to send POST request to add a meal
    function addMeal() {
        const food = foodInput.value.trim();
        const time = timeInput.value.trim();
        const calories = caloriesInput.value.trim();
        if (food === '' || time === '' || calories === '') {
            return;
        }
        fetch('http://localhost:3030/jsonstore/tasks/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                food,
                time,
                calories
            })
        })
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                throw new Error('Failed to add meal.');
            })
            .then(() => {
                loadMeals(); // Reload meals after adding
                foodInput.value = '';
                timeInput.value = '';
                caloriesInput.value = '';
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }

    // Function to send DELETE request to remove a meal
    function deleteMeal(mealId) {
        fetch(`http://localhost:3030/jsonstore/tasks/${mealId}`, {
            method: 'DELETE'
        })
            .then(() => loadMeals()); // Reload meals after deleting
    }

    // Load meals on page load
    loadMealsBtn.addEventListener('click', loadMeals);

    // Add meal button click event listener
    addMealBtn.addEventListener('click', addMeal);

    // Edit meal button click event listener
    mealList.addEventListener('click', function (e) {
        if (e.target.classList.contains('change-meal')) {
            const mealDiv = e.target.closest('.meal');
            const mealId = mealDiv.dataset.id;
            // Code to populate input fields with meal data and activate edit meal button
            // Then, remove the meal from the DOM structure
        }
    });

    // Edit meal button click event listener
    editMealBtn.addEventListener('click', function () {
        // Code to send PUT request to update meal data
        // Then, reload meals and deactivate edit meal button
    });

    // Delete meal button click event listener
    mealList.addEventListener('click', function (e) {
        if (e.target.classList.contains('delete-meal')) {
            const mealDiv = e.target.closest('.meal');
            const mealId = mealDiv.dataset.id;
            deleteMeal(mealId);
        }
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const loadMealsBtn = document.getElementById('loadMealsBtn');
    const addMealBtn = document.getElementById('addMealBtn');
    const editMealBtn = document.getElementById('editMealBtn');
    const deleteMealBtn = document.getElementById('deleteMealBtn');
    const mealList = document.getElementById('list');
    const foodInput = document.getElementById('food');
    const timeInput = document.getElementById('time');
    const caloriesInput = document.getElementById('calories');

    // Function to send GET request to load meals
    function loadMeals() {
        fetch('http://localhost:3030/jsonstore/tasks/')
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                throw new Error('Failed to load meals.');
            })
            .then(data => {
                mealList.innerHTML = ''; // Clear existing meals
                Object.values(data).forEach(meal => {
                    const { food, time, calories } = meal;
                    const mealItem = document.createElement('div');
                    mealItem.classList.add('meal');
                    mealItem.innerHTML = `
                        <h2>${food}</h2>
                        <h3>${time}</h3>
                        <h3>${calories}</h3>
                        <div id="meal-buttons">
                            <button class="change-meal">Change</button>
                            <button class="delete-meal">Delete</button>
                        </div>
                    `;
                    mealList.appendChild(mealItem);
                });
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }


    // Function to send POST request to add a meal
    function addMeal() {
        const food = foodInput.value.trim();
        const time = timeInput.value.trim();
        const calories = caloriesInput.value.trim();
        if (food === '' || time === '' || calories === '') {
            return;
        }
        fetch('http://localhost:3030/jsonstore/tasks/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                food,
                time,
                calories
            })
        })
            .then(() => {
                loadMeals(); // Reload meals after adding
                foodInput.value = '';
                timeInput.value = '';
                caloriesInput.value = '';
            });
    }

    // Function to send DELETE request to remove a meal
    function deleteMeal(mealId) {
        fetch(`http://localhost:3030/jsonstore/tasks/${mealId}`, {
            method: 'DELETE'
        })
            .then(() => loadMeals()); // Reload meals after deleting
    }

    // Load meals on page load
    loadMealsBtn.addEventListener('click', loadMeals);

    // Add meal button click event listener
    addMealBtn.addEventListener('click', addMeal);

    // Edit meal button click event listener
    mealList.addEventListener('click', function (e) {
        if (e.target.classList.contains('change-meal')) {
            const mealDiv = e.target.closest('.meal');
            const mealId = mealDiv.dataset.id;
            // Code to populate input fields with meal data and activate edit meal button
            // Then, remove the meal from the DOM structure
        }
    });

    // Edit meal button click event listener
    editMealBtn.addEventListener('click', function () {
        // Code to send PUT request to update meal data
        // Then, reload meals and deactivate edit meal button
    });

    // Delete meal button click event listener
    mealList.addEventListener('click', function (e) {
        if (e.target.classList.contains('delete-meal')) {
            const mealDiv = e.target.closest('.meal');
            const mealId = mealDiv.dataset.id;
            deleteMeal(mealId);
        }
    });
});
