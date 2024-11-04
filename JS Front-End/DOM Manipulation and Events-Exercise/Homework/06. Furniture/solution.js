function solve() {
  const generateBtn = document.querySelector('button:first-of-type');
  const buyBtn = document.querySelector('button:last-of-type');
  const furnitureDataTextarea = document.getElementById('furnitureData');

  generateBtn.addEventListener('click', generateTable);
  buyBtn.addEventListener('click', buyFurniture);

  function generateTable() {
      const furnitureData = JSON.parse(furnitureDataTextarea.value);
      const tbody = document.querySelector('#furnitureTable tbody');

      tbody.innerHTML = ''; // Clear the table body before generating new rows

      furnitureData.forEach(furniture => {
          const row = document.createElement('tr');
          row.innerHTML = `
              <td><img src="${furniture.img}" alt="${furniture.name}" style="width: 100px;"></td>
              <td>${furniture.name}</td>
              <td>${furniture.price}</td>
              <td>${furniture.decFactor}</td>
              <td><input type="checkbox" name="furnitureCheckbox" value="${furniture.name}"></td>
          `;
          tbody.appendChild(row);
      });
  }

  function buyFurniture() {
      const checkboxes = document.querySelectorAll('input[name="furnitureCheckbox"]:checked');
      const resultTextarea = document.getElementById('result');
      let totalPrice = 0;
      let totalDecFactor = 0;

      let boughtFurniture = Array.from(checkboxes).map(checkbox => checkbox.value).join(', ');
      let furnitureCount = checkboxes.length;

      checkboxes.forEach(checkbox => {
          const row = checkbox.closest('tr');
          totalPrice += parseFloat(row.children[2].textContent);
          totalDecFactor += parseFloat(row.children[3].textContent);
      });

      resultTextarea.value = `Bought furniture: ${boughtFurniture}\n`;
      resultTextarea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
      resultTextarea.value += `Average decoration factor: ${(totalDecFactor / furnitureCount).toFixed(2)}`;
  }
}

