function addItem() {
    const inputElement = document.getElementById('newItemText');
    const itemListElements = document.getElementById('items');

    const newItemElement = document.createElement('li');
    newItemElement.textContent = inputElement.value;
    itemListElements.appendChild(newItemElement);
    inputElement.value = '';
}
