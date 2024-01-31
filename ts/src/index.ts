import { day1_1, day1_2 } from './2023/day1'
import { day2_1, day2_2 } from './2023/day2'
import { day3_1 } from './2023/day3'

const solutions = [day1_1, day1_2, day2_1, day2_2, day3_1]

solutions.forEach(solution => {
  console.log(`Solution for ${solution.name} is ${solution()}`)
})
