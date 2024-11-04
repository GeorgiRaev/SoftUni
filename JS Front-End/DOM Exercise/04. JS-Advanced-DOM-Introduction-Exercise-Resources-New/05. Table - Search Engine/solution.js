function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const trElements = document.querySelectorAll('table.container tbody tr');
      const searchFiedElement = document.getElementById('searchField');
      const serchText = searchFiedElement.value;

      for (const trElement of trElements) {
         const tdElements = trElement.querySelectorAll('td');
         let isSelected = false;
         trElement.classList.remove('select');

         for (const tdElement of tdElements) {
            if (tdElement.textContent.includes(serchText)) {
               isSelected = true;
               break;
            }
         }
         if (isSelected === true) {
            trElement.classList.add('select');
         }
      }
      searchFiedElement.value = '';
   }
}