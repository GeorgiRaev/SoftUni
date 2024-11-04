function solve(input){
    let wordsArray = input.split(/(?=[A-Z])/);

    // Join the words with a comma and space
    let result = wordsArray.join(', ');

    console.log(result);
}
solve('SplitMeIfYouCanHaHaYouCantOrYouCan')