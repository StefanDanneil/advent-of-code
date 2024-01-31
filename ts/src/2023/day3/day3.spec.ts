import { day3_1, day3_2 } from './day3'

const testInput = [
  '467..114..',
  '...*......',
  '..35..633.',
  '......#...',
  '617*......',
  '.....+.58.',
  '..592.....',
  '......755.',
  '...$.*....',
  '.664.598..',
]

describe('day2_1', () => {
  test('it should return 8 given the example', () => {
    expect(day3_1(testInput)).toBe(4361)
  })
})

describe('day2_2', () => {
  test('it should return 900 given the example', () => {
    expect(day3_2(testInput)).toBe(467835)
  })
})
