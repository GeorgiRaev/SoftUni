function create(words) {
   const contentElement = document.getElementById('content');
   const divElements = words
      .map(word => {
         const divElement = document.createElement('div');
         const pElement = document.createElement('p');
         pElement.textContent = word;
         pElement.style.display = 'none';
         divElement.appendChild(pElement);
         return divElement;
      });

   divElements
      .forEach(divElement => {
         divElement.addEventListener('click', () => {
            const pElement = divElement.querySelector('p');
            pElement.style.display = 'block';
         })
      });
   divElements.forEach(divElement => contentElement.appendChild(divElement));
}
