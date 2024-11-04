function colorize() {
    // TODO
    const evenRowsElements = document.querySelectorAll('table tr:nth-child(2n)')
    evenRowsElements.forEach(element => element.style.backgroundColor = 'teal');
}