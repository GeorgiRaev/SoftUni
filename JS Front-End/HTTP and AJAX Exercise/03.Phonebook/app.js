function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';

    const loadButtonElement = document.getElementById('btnLoad');
    const btnCreateButtonElement = document.getElementById('btnCreate')
    const phonebookElement = document.getElementById('phonebook');
    const personlement = document.getElementById('person');
    const phoneElement = document.getElementById('phone');

    loadButtonElement.addEventListener('click', () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(date => {
                Object.values(data)
                .forEach(entry => {
                    const liElement = document.getElementById('li');
                    liElement.textContent = `${entry.person}:${entry.phone}`;
                    const deleteButton = document.createElement('button');
                    deleteButton.textContent ='Delete';
                })
            });
    })

}

attachEvents();