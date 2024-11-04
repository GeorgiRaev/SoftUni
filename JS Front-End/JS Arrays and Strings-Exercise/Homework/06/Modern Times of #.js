function solve(input) {
    // Use a regular expression to find words starting with '#'
    let specialWords = input.match(/#([a-zA-Z]+)/g);

    // Filter out invalid special words (not consisting only of letters)
    let validSpecialWords = specialWords.filter(word => /^[a-zA-Z]+$/.test(word.slice(1)));

    // Print the valid special words without the label '#'
    validSpecialWords.forEach(word => console.log(word.slice(1)));
}
solve('Nowadays everyone uses # to tag a #special word in #socialMedia')

