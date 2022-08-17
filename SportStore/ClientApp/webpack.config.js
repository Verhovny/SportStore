
const path = require('path');
MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
       
       
        validate: "./src/js/validate.js",
        index: './src/js/index.js'
       
    },

    resolve: {
        extensions: ['.tsx', '.ts', '.js','.css'],
    },

    output: {

        library: {
            name: 'MYAPP',
            type: 'var'
        },

        filename: '[name].entry.js',
        path: path.resolve(__dirname, '..', 'wwwroot', 'dist')
    },
    devtool: 'source-map',
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.css$/,
                //use: ['style-loader', 'css-loader'],
                use: [{ loader: MiniCssExtractPlugin.loader }, 'css-loader']
            },
            {
                test: /\.(eot|woff(2)?|ttf|otf|svg)$/i,
                type: 'asset'
            },

            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            }

        ]
    },

    plugins: [
        new MiniCssExtractPlugin({ filename: "[name].css" })
    ]

};
