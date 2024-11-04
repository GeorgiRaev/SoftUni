document.addEventListener('DOMContentLoaded', function () {
    function solve() {
        const addBtn = document.getElementById('add-btn');
        const previewList = document.getElementById('preview-list');
        const expensesList = document.getElementById('expenses-list');
        const deleteBtn = document.querySelector('.btn.delete'); // Get the [Delete] button

        // Function to create a new expense item
        function createExpenseItem(expense, amount, date) {
            const listItem = document.createElement('li');
            listItem.classList.add('expense-item');
            const article = document.createElement('article');
            article.innerHTML = `<p>Type: ${expense}</p>
                                 <p>Amount: ${amount}$</p>
                                 <p>Date: ${date}</p>`;
            listItem.appendChild(article);

            // Create edit and ok buttons
            const buttonsDiv = document.createElement('div');
            buttonsDiv.classList.add('buttons');
            const editBtn = document.createElement('button');
            editBtn.classList.add('btn', 'edit');
            editBtn.textContent = 'Edit';
            const okBtn = document.createElement('button');
            okBtn.classList.add('btn', 'ok');
            okBtn.textContent = 'OK';
            buttonsDiv.appendChild(editBtn);
            buttonsDiv.appendChild(okBtn);
            listItem.appendChild(buttonsDiv);

            return listItem;
        }

        // Add button click event listener
        addBtn.addEventListener('click', function () {
            // Get input values
            const expenseInput = document.getElementById('expense');
            const amountInput = document.getElementById('amount');
            const dateInput = document.getElementById('date');
            const expense = expenseInput.value.trim();
            const amount = amountInput.value.trim();
            const date = dateInput.value.trim();

            // Validate input
            if (expense === '' || amount === '' || date === '') {
                return;
            }

            // Create new list item
            const listItem = createExpenseItem(expense, amount, date);

            // Add the new item to the preview list
            previewList.appendChild(listItem);

            // Disable the Add button
            addBtn.disabled = true;

            // Clear input fields
            expenseInput.value = '';
            amountInput.value = '';
            dateInput.value = '';
        });

        // OK button click event listener
        previewList.addEventListener('click', function (e) {
            if (e.target.classList.contains('ok')) {
                // Get the parent li element
                const listItem = e.target.closest('.expense-item');
                if (listItem) {
                    // Remove the listItem from the preview list
                    previewList.removeChild(listItem);

                    // Remove the edit and ok buttons from the listItem
                    const buttonsDiv = listItem.querySelector('.buttons');
                    if (buttonsDiv) {
                        buttonsDiv.parentNode.removeChild(buttonsDiv);
                    }

                    // Add the listItem to the expenses list
                    expensesList.appendChild(listItem);

                    // Enable the Add button
                    addBtn.disabled = false;
                }
            }
        });

        // Delete button click event listener
        deleteBtn.addEventListener('click', function () {
            location.reload(); // Reload the application
        });
    }

    // Call the expenseTracker function
    solve();
});
