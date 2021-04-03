/**
 * @param {string} s
 * @return {number}
 */
 var romanToInt = function(s) {
    let map = new Map(); //создание нового объекта
    map.set('I', 1).set('V', 5) //добавление ключей и значений в словарь
    map.set('X', 10).set('L', 50).set('C', 100).set('D', 500).set('M', 1000)
    
    let array = new Array(); 
    array = Array.from(s); //превратили строку в массив односимвольных строк
    
    let result = 0; 
    for (let i = 0; i < array.length-1; i++) 
    {
        if (map.has(array[i]) && map.has(array[i+1])) // проверка, являются ли элементы
        {                                             // массива ключами словаря
            let first = map.get(array[i]); // поиск значения по ключу
            let second = map.get(array[i+1]); 

            if (first >= second) {
                result += first
            } else {
                first *= -1;
                result += first
            }
            continue;
        }
        return 0;
    }

    let temp = map.get(array[array.length-1]); // получение значения последнего элемента 
    result += temp                             // массива
    return result;
};