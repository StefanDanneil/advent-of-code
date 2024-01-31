import { day2Input } from './day2.input'

export function day2_1(input: string = day2Input): number {
  const colorMap: { [key: string]: number } = {
    red: 12,
    green: 13,
    blue: 14,
  }

  return input
    .split('\n')
    .map(row => {
      let [game, sets] = row.split(':')
      var evaluated = sets.split(';').map(set => {
        return set
          .split(',')
          .map(x => {
            let [count, color] = x.trim().split(' ')

            if (color in colorMap && colorMap[color] < parseInt(count)) return false

            return true
          })
          .includes(false)
      })

      if (!evaluated.includes(true)) {
        const [_, id] = game.trim().split(' ')
        return parseInt(id)
      }
      return 0
    })
    .reduce((a, b) => a + b, 0)
}

export function day2_2(input: string = day2Input): number {
  let games = input.split('\n')
  let gamePowerValues: number[] = []

  games.forEach(game => {
    let greens: number[] = []
    let blues: number[] = []
    let reds: number[] = []

    let [_, sets] = game.split(':')

    sets.split(';').forEach(set => {
      set.split(',').forEach(balls => {
        let [count, color] = balls.trim().split(' ')

        switch (color) {
          case 'green':
            greens.push(parseInt(count))
            break
          case 'blue':
            blues.push(parseInt(count))
            break
          case 'red':
            reds.push(parseInt(count))
            break
          default:
            throw new Error(`Could not find a matching color for '${color}'`)
        }
      })
    })

    reds.sort((a, b) => b - a)
    blues.sort((a, b) => b - a)
    greens.sort((a, b) => b - a)

    var output = 1

    if (reds.length > 0) {
      output *= reds[0]
    }

    if (blues.length > 0) {
      output *= blues[0]
    }

    if (greens.length > 0) {
      output *= greens[0]
    }

    gamePowerValues.push(output)
  })

  return gamePowerValues.reduce((a, b) => a + b, 0)
}
