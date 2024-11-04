function solve() {
    const loadBtn = document.getElementById('load-games');
    const addBtn = document.getElementById('add-game');
    const editBtn = document.getElementById('edit-game');
    const gamesList = document.getElementById('games-list');

    loadBtn.addEventListener('click', loadGames);
    addBtn.addEventListener('click', addGame);
    editBtn.addEventListener('click', editGame);

    const nameInput = document.getElementById('g-name');
    const typeInput = document.getElementById('type');
    const playersInput = document.getElementById('players');

    async function loadGames() {
        try {
            const response = await fetch('http://localhost:3030/jsonstore/games/');
            const data = await response.json();
            gamesList.innerHTML = '';
            Object.values(data).forEach(game => {
                const { name, type, players, _id } = game;
                const gameElement = createGameElement(name, type, players, _id);
                gamesList.appendChild(gameElement);
            });
        } catch (error) {
            console.error('Error loading games:', error);
        }
    }

    async function addGame() {
        const name = nameInput.value.trim();
        const type = typeInput.value.trim();
        const players = playersInput.value.trim();

        if (!name || !type || !players) {
            alert('Please fill in all fields.');
            return;
        }

        const newGame = { name, type, players };

        try {
            await fetch('http://localhost:3030/jsonstore/games/', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newGame)
            });
            nameInput.value = '';
            typeInput.value = '';
            playersInput.value = '';
            loadGames();
        } catch (error) {
            console.error('Error adding game:', error);
        }
    }

    async function editGame() {
        const name = nameInput.value.trim();
        const type = typeInput.value.trim();
        const players = playersInput.value.trim();

        if (!name || !type || !players) {
            alert('Please fill in all fields.');
            return;
        }

        const gameId = editBtn.dataset.id;

        const updatedGame = { name, type, players };

        try {
            await fetch(`http://localhost:3030/jsonstore/games/${gameId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(updatedGame)
            });
            nameInput.value = '';
            typeInput.value = '';
            playersInput.value = '';
            editBtn.disabled = true;
            addBtn.disabled = false;
            loadGames();
        } catch (error) {
            console.error('Error editing game:', error);
        }
    }

    function createGameElement(name, type, players, id) {
        const gameDiv = document.createElement('div');
        gameDiv.classList.add('board-game');

        const contentDiv = document.createElement('div');
        contentDiv.classList.add('content');
        contentDiv.innerHTML = `
            <p>${name}</p>
            <p>${type}</p>
            <p>${players}</p>
        `;
        gameDiv.appendChild(contentDiv);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons-container');

        const editBtn = document.createElement('button');
        editBtn.classList.add('change-btn');
        editBtn.textContent = 'Change';
        editBtn.addEventListener('click', function () {
            editBtn.dataset.id = id;
            nameInput.value = name;
            typeInput.value = type;
            playersInput.value = players;
            addBtn.disabled = true;
            editBtn.disabled = false;
        });
        buttonsDiv.appendChild(editBtn);

        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', async function () {
            try {
                await fetch(`http://localhost:3030/jsonstore/games/${id}`, {
                    method: 'DELETE'
                });
                loadGames();
            } catch (error) {
                console.error('Error deleting game:', error);
            }
        });
        buttonsDiv.appendChild(deleteBtn);

        gameDiv.appendChild(buttonsDiv);

        return gameDiv;
    }
}

solve();
