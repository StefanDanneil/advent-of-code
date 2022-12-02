import { day2_1, day2_2 } from './day2'

const solutions = [day2_1, day2_2]

solutions.forEach(solution => {
  console.log(`Solution for ${solution.name} is ${solution()}`)
})
