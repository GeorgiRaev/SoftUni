/*function getAsciiCodes(firstCharacter, secondCharacter) {
    let firstChar = firstCharacter.charCodeAt(0);
    let secondChar = secondCharacter.charCodeAt(0);

    for (let i = Math.min(firstChar, secondChar) + 1; i < Math.max(firstChar, secondChar); i++); {
        console.log(String.fromCharCode(i));
    }
}
getAsciiCodes('a',
'd'
)
*/

function printCharactersBetween(firstCharacter, secondCharacter) {

    let firstChar = firstCharacter.charCodeAt(0);
    let secondChar = secondCharacter.charCodeAt(0);
    let result = [];

    for (let i = Math.min(firstChar, secondChar) + 1; i < Math.max(firstChar, secondChar); i++) {
        result.push(String.fromCharCode(i));
        
    }
    console.log(result.join(' '));
}

printCharactersBetween('a', 'd');
