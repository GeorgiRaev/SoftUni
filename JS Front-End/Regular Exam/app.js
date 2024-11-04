window.addEventListener("load", solve);

function solve() {
    const addBtn = document.getElementById('add-btn');
    const checkList = document.getElementById('check-list');
    const contactList = document.getElementById('contact-list');

    addBtn.addEventListener('click', addContact);

    function addContact() {
        const nameInput = document.getElementById('name');
        const phoneInput = document.getElementById('phone');
        const categoryInput = document.getElementById('category');

        const name = nameInput.value.trim();
        const phone = phoneInput.value.trim();
        const category = categoryInput.value.trim();

        if (name === '' || phone === '' || category === '') {
            
        }

        const li = document.createElement('li');
        const article = document.createElement('article');

        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = `name:${name}`;
        article.appendChild(nameParagraph);

        const phoneParagraph = document.createElement('p');
        phoneParagraph.textContent = `phone:${phone}`;
        article.appendChild(phoneParagraph);

        const categoryParagraph = document.createElement('p');
        categoryParagraph.textContent = `category:${category}`;
        article.appendChild(categoryParagraph);

        li.appendChild(article);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');

        const editButton = document.createElement('button');
        editButton.classList.add('edit-btn');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', editContact);
        buttonsDiv.appendChild(editButton);

        const saveButton = document.createElement('button');
        saveButton.classList.add('save-btn');
        saveButton.textContent = 'Save';
        saveButton.addEventListener('click', saveContact);
        buttonsDiv.appendChild(saveButton);

        li.appendChild(buttonsDiv);

        checkList.appendChild(li);

        nameInput.value = '';
        phoneInput.value = '';
        categoryInput.value = '';
    }

    function editContact(event) {
        const li = event.target.closest('li');
        const article = li.querySelector('article');
        const name = article.querySelector('p:first-child').textContent.split(':')[1];
        const phone = article.querySelector('p:nth-child(2)').textContent.split(':')[1];
        const category = article.querySelector('p:nth-child(3)').textContent.split(':')[1];

        const nameInput = document.getElementById('name');
        nameInput.value = name;

        const phoneInput = document.getElementById('phone');
        phoneInput.value = phone;

        const categoryInput = document.getElementById('category');
        categoryInput.value = category;

        const editButton = li.querySelector('.edit-btn');
        editButton.style.display = 'none';

        const saveButton = li.querySelector('.save-btn');
        saveButton.style.display = 'inline-block';
    }

    function saveContact(event) {
        const li = event.target.closest('li');
        const article = li.querySelector('article');
        const name = article.querySelector('p:first-child').textContent.split(':')[1];
        const phone = article.querySelector('p:nth-child(2)').textContent.split(':')[1];
        const category = article.querySelector('p:nth-child(3)').textContent.split(':')[1];
    
        
        const contactName = name; 
        const contactPhone = phone.toLowerCase(); 
        const contactCategory = category.toLowerCase(); 
    
        const contactLi = document.createElement('li');
        const contactArticle = document.createElement('article');
    
        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = `name:${contactName}`; 
        contactArticle.appendChild(nameParagraph);
    
        const phoneParagraph = document.createElement('p');
        phoneParagraph.textContent = `phone:${contactPhone}`; 
        contactArticle.appendChild(phoneParagraph);
    
        const categoryParagraph = document.createElement('p');
        categoryParagraph.textContent = `category:${contactCategory}`;
        contactArticle.appendChild(categoryParagraph);
    
        contactLi.appendChild(contactArticle);
        contactList.appendChild(contactLi);
    
        li.remove();
    
        const nameInput = document.getElementById('name');
        nameInput.value = '';
    
        const phoneInput = document.getElementById('phone');
        phoneInput.value = '';
    
        const categoryInput = document.getElementById('category');
        categoryInput.value = '';
    }
}
