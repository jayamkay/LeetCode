/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
    let counter = 0;
    let array = [];
    let temp;
    array.push(s[0]);
    for (let i = 1; i < s.length; i++) {
        if (array.length == 0) {
            temp = s[i];
        }
        else {
            temp = array[array.length - 1];
        }

        array.push(s[i])
        if ((temp == '(' && s[i] == ')') || (temp == '[' && s[i] == ']') || (temp == '{' && s[i] == '}')) {
            array.pop();
            array.pop();
            counter += 2;
        }
    }
    var result = counter == s.length;
    return result;   

    // return counter == s.length ? true : false;
};