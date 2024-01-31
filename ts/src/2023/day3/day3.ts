import { day3Input } from './day3.input'

const digits = '0123456789'

export function day3_1(input: string[] = day3Input): number {
  var sum = 0
  var symbolCoordinates = getSymbolCoordinates(input)

  for (let rowIndex = 0; rowIndex < input.length; rowIndex++) {
    let row = input[rowIndex]

    for (let columnIndex = 0; columnIndex < row.length; columnIndex++) {
      if (digits.includes(row[columnIndex])) {
        var numberString = getCurrentNumberString(row, columnIndex)

        if (checkIfAdjacentToSymbol(rowIndex, columnIndex, columnIndex + numberString.length - 1, symbolCoordinates)) {
          sum += parseInt(numberString)
        }

        columnIndex += numberString.length - 1
      }
    }
  }

  return sum
}

export function day3_2(input: string[] = day3Input) {
  var sum = 0
  var symbolCoordinates = getSymbolCoordinates(input)

  for (const [key, value] of Object.entries(symbolCoordinates)) {
    if (value !== '*') continue

    sum += getGearRatio(key, input)
  }

  return sum
}

function getSymbolCoordinates(input: string[]): { [key: string]: string } {
  let coordinates: { [key: string]: string } = {}

  for (let rowIndex = 0; rowIndex < input.length; rowIndex++) {
    let row = input[rowIndex]

    for (let columnIndex = 0; columnIndex < row.length; columnIndex++) {
      let currentCharacter = row[columnIndex]

      if (!digits.includes(currentCharacter) && currentCharacter !== '.') {
        coordinates[`${columnIndex},${rowIndex}`] = currentCharacter
      }
    }
  }

  return coordinates
}

function getCurrentNumberString(row: string, startingIndex: number): string {
  let output = ''

  for (var i = startingIndex; i < row.length; i++) {
    if (!digits.includes(row[i])) break
    output += row[i]
  }

  return output
}

function checkIfAdjacentToSymbol(
  rowIndex: number,
  startIndex: number,
  stopIndex: number,
  symbolCoordinates: { [key: string]: string },
): boolean {
  for (let i = startIndex; i <= stopIndex; i++) {
    const left = `${i - 1},${rowIndex}`
    const upperLeft = `${i - 1},${rowIndex - 1}`
    const upper = `${i},${rowIndex - 1}`
    const upperRight = `${i + 1},${rowIndex - 1}`
    const right = `${i + 1},${rowIndex}`
    const lowerRight = `${i + 1},${rowIndex + 1}`
    const lower = `${i},${rowIndex + 1}`
    const lowerLeft = `${i - 1},${rowIndex + 1}`

    if (
      symbolCoordinates[left] !== undefined ||
      symbolCoordinates[upperLeft] !== undefined ||
      symbolCoordinates[upper] !== undefined ||
      symbolCoordinates[upperRight] !== undefined ||
      symbolCoordinates[right] !== undefined ||
      symbolCoordinates[lowerRight] !== undefined ||
      symbolCoordinates[lower] !== undefined ||
      symbolCoordinates[lowerLeft] !== undefined
    ) {
      return true
    }
  }

  return false
}

function getGearRatio(gearCoordinates: string, input: string[]): number {
  const [x, y] = gearCoordinates.split(',').map(n => parseInt(n))
  const foundNumbers: number[] = []

  for (let i = x - 1; i <= x + 1; i++) {
    for (let j = y - 1; j <= y + 1; j++) {
      const currentPosition = input[j][i]

      if (digits.includes(currentPosition)) {
      }
    }
  }

  return 0
}
