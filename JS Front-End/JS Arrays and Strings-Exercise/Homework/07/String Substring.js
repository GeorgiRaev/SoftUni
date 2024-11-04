function solve(word,text){
    const words = text.toLowerCase().split(' ');
    const isIncludet = words.includes(word.toLowerCase());
    if(isIncludet){
        return console.log(word);
    }
    else{
        console.log(`${word} not found!`);
    }
}
const result = solve('javascript',
'JavaScript is the best programming language')
