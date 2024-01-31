import { day1Input } from './day1.input'

const digits = '0123456789'

const stringDigits = ['one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine']

export function day1_1(input: string[] = day1Input): number {
  return input
    .map(row => {
      let numberChars = row.split('').filter(c => digits.includes(c))
      var number = numberChars[0].concat(numberChars[numberChars.length - 1])
      return parseInt(number)
    })
    .reduce((a, b) => a + b, 0)
}

export function day1_2(input: string[] = day1Input) {
  return input
    .map(row => {
      var numberCharactersInRow = ''

      for (let i = 0; i < row.length; i++) {
        if (digits.includes(row[i])) {
          numberCharactersInRow += row[i]
        } else {
          for (let stringDigit of stringDigits) {
            if (stringDigit === row.substring(i, i + stringDigit.length)) {
              numberCharactersInRow += stringDigitToNumberCharacter(stringDigit)
            }
          }
        }
      }
      var number = numberCharactersInRow[0].concat(numberCharactersInRow[numberCharactersInRow.length - 1])
      return parseInt(number)
    })
    .reduce((a, b) => a + b, 0)
}

function stringDigitToNumberCharacter(stringDigit: string): string {
  switch (stringDigit) {
    case 'one':
      return '1'
    case 'two':
      return '2'
    case 'three':
      return '3'
    case 'four':
      return '4'
    case 'five':
      return '5'
    case 'six':
      return '6'
    case 'seven':
      return '7'
    case 'eight':
      return '8'
    case 'nine':
      return '9'
    default:
      throw new Error('could not match number string')
  }
}
