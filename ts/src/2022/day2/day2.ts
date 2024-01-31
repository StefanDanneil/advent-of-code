import { day2_input } from './day2.input'

const shapeValueMap: { [key: string]: number } = {
  A: 1,
  B: 2,
  C: 3,
  X: 1,
  Y: 2,
  Z: 3,
}

const getShapeValue = (input: string): number => {
  if (!Object.keys(shapeValueMap).includes(input)) throw 'stuff went wrong'

  return shapeValueMap[input]
}

const calculateScore = (opponentValue: number, playerValue: number) => {
  // tie
  if (opponentValue === playerValue) return 3 + playerValue

  // rock is beaten by paper
  if (playerValue === 1 && opponentValue === 2) return playerValue

  // paper is beaten by scissors
  if (playerValue === 2 && opponentValue === 3) return playerValue

  // scissors is beaten by rock
  if (playerValue === 3 && opponentValue === 1) return playerValue

  // win
  return 6 + playerValue
}

export function day2_1(input: string[] = day2_input): number {
  return input
    .map(game => {
      var shapes = game.split(' ')
      var opponentValue = getShapeValue(shapes[0])
      var playervalue = getShapeValue(shapes[1])
      return calculateScore(opponentValue, playervalue)
    })
    .reduce((a, b) => a + b, 0)
}

export function day2_2(input: string[] = day2_input) {
  return input
    .map(game => {
      var shapes = game.split(' ')
      var opponentValue = getShapeValue(shapes[0])

      if (shapes[1] === 'X') return calculateScore(opponentValue, getLosingValue(opponentValue))
      if (shapes[1] === 'Y') return calculateScore(opponentValue, opponentValue)
      if (shapes[1] === 'Z') return calculateScore(opponentValue, getWinningValue(opponentValue))
      throw 'argument not valid'
    })
    .reduce((a, b) => a + b, 0)
}

const getLosingValue = (valueToLoseTo: number): number => {
  switch (valueToLoseTo) {
    case 1:
      return 3
    case 2:
      return 1
    case 3:
      return 2
    default:
      throw 'argument not valid'
  }
}

const getWinningValue = (valueToBeat: number): number => {
  switch (valueToBeat) {
    case 1:
      return 2
    case 2:
      return 3
    case 3:
      return 1
    default:
      throw 'argument not valid'
  }
}
