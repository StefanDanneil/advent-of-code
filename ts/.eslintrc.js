module.exports = {
    parser: '@typescript-eslint/parser', // Specifies the ESLint parser
    extends: [
      'plugin:react/recommended', // Uses the recommended rules from @eslint-plugin-react
      'plugin:@typescript-eslint/recommended', // Uses the recommended rules from @typescript-eslint/eslint-plugin
      'prettier/@typescript-eslint', // Uses eslint-config-prettier to disable ESLint rules from @typescript-eslint/eslint-plugin that would conflict with prettier
      'plugin:prettier/recommended', // Enables eslint-plugin-prettier and displays prettier errors as ESLint errors. Make sure this is always the last configuration in the extends array.
    ],
    parserOptions: {
      ecmaVersion: 2018, // Allows for the parsing of modern ECMAScript features
      sourceType: 'module', // Allows for the use of imports
      ecmaFeatures: {
        jsx: true, // Allows for the parsing of JSX
      },
    },
    rules: {
      // Place to specify ESLint rules. Can be used to overwrite rules specified from the extended configs
      '@typescript-eslint/no-unused-vars': 'error',
      // TODO remove these rules and clean up all the mess
      'react/no-children-prop': 'off',
      '@typescript-eslint/ban-types': 'off',
      'react/display-name': 'off',
      //'@typescript-eslint/no-explicit-any': 'off',
      eqeqeq: 2,
    },
    overrides: [
      {
        files: ['*.js', '*.jsx'],
        rules: {
          '@typescript-eslint/explicit-module-boundary-types': 'off', // don't require js files to use type annotations
        },
      },
    ],
    settings: {
      react: {
        version: 'detect', // Tells eslint-plugin-react to automatically detect the version of React to use
      },
    },
  }
  