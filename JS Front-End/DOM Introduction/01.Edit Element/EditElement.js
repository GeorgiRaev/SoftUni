function editElement() {
    const currentElement = element.textContent;
    element.textContent = element.textContent.replace(new RegExp(match, 'g'), replacer);
}