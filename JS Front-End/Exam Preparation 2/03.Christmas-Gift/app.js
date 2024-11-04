document.addEventListener('DOMContentLoaded', function () {
    const loadBtn = document.getElementById('load-presents');
    const addBtn = document.getElementById('add-present');
    const editBtn = document.getElementById('edit-present');
    const giftList = document.getElementById('gift-list');

    loadBtn.addEventListener('click', loadPresents);
    addBtn.addEventListener('click', addPresent);

    async function loadPresents() {
        try {
            const response = await fetch('http://localhost:3030/jsonstore/gifts');
            const data = await response.json();
            giftList.innerHTML = '';
            Object.entries(data).forEach(([id, gift]) => {
                const { gift: name, for: recipient, price } = gift;
                const giftElement = createGiftElement(id, name, recipient, price);
                giftList.appendChild(giftElement);
            });
        } catch (error) {
            console.error('Error loading presents:', error);
        }
    }

    async function addPresent() {
        const giftInput = document.getElementById('gift');
        const forInput = document.getElementById('for');
        const priceInput = document.getElementById('price');
        const gift = giftInput.value;
        const recipient = forInput.value;
        const price = priceInput.value;

        if (!gift || !recipient || !price) {
            alert('Please fill in all fields.');
            return;
        }

        const newGift = {
            gift,
            for: recipient,
            price
        };

        try {
            const response = await fetch('http://localhost:3030/jsonstore/gifts', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newGift)
            });
            if (!response.ok) {
                throw new Error('Failed to add gift.');
            }
            giftInput.value = '';
            forInput.value = '';
            priceInput.value = '';
            loadPresents();
        } catch (error) {
            console.error('Error adding present:', error);
        }
    }

    function createGiftElement(id, name, recipient, price) {
        const giftElement = document.createElement('div');
        giftElement.classList.add('gift-sock');
        giftElement.innerHTML = `
            <div class="content">
                <p>${name}</p>
                <p>${recipient}</p>
                <p>${price}</p>
            </div>
            <div class="buttons-container">
                <button class="change-btn" data-id="${id}">Change</button>
                <button class="delete-btn" data-id="${id}">Delete</button>
            </div>`;
        return giftElement;
    }

    document.addEventListener('click', async function(event) {
        if (event.target.classList.contains('change-btn')) {
            const giftId = event.target.dataset.id;
            const giftElement = event.target.closest('.gift-sock');
            const giftName = giftElement.querySelector('.content p:first-child').textContent;
            const giftRecipient = giftElement.querySelector('.content p:nth-child(2)').textContent;
            const giftPrice = giftElement.querySelector('.content p:nth-child(3)').textContent;
            
            // Populate input fields with gift data
            const giftInput = document.getElementById('gift');
            const forInput = document.getElementById('for');
            const priceInput = document.getElementById('price');
            giftInput.value = giftName;
            forInput.value = giftRecipient;
            priceInput.value = giftPrice;
            
            // Enable edit mode
            const editBtn = document.getElementById('edit-present');
            editBtn.dataset.id = giftId;
            editBtn.disabled = false;
            addBtn.disabled = true;
        } else if (event.target.classList.contains('edit-present')) {
            const giftId = event.target.dataset.id;
            const giftInput = document.getElementById('gift');
            const forInput = document.getElementById('for');
            const priceInput = document.getElementById('price');
            const gift = giftInput.value;
            const recipient = forInput.value;
            const price = priceInput.value;

            if (!gift || !recipient || !price) {
                alert('Please fill in all fields.');
                return;
            }

            const updatedGift = {
                gift,
                for: recipient,
                price
            };

            try {
                const response = await fetch(`http://localhost:3030/jsonstore/gifts/${giftId}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(updatedGift)
                });
                if (!response.ok) {
                    throw new Error('Failed to edit gift.');
                }
                giftInput.value = '';
                forInput.value = '';
                priceInput.value = '';
                loadPresents();
                const editBtn = document.getElementById('edit-present');
                editBtn.dataset.id = '';
                editBtn.disabled = true;
                addBtn.disabled = false;
            } catch (error) {
                console.error('Error editing present:', error);
            }
        } else if (event.target.classList.contains('delete-btn')) {
            const giftId = event.target.dataset.id;

            try {
                const response = await fetch(`http://localhost:3030/jsonstore/gifts/${giftId}`, {
                    method: 'DELETE'
                });
                if (!response.ok) {
                    throw new Error('Failed to delete gift.');
                }
                loadPresents();
            } catch (error) {
                console.error('Error deleting present:', error);
            }
        }
    });
});
