const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CleanWebpackPlugin = require("clean-webpack-plugin");

const BUILD_DIR = path.resolve(__dirname, "wwwroot");
const APP_DIR = path.resolve(__dirname, "ClientApp");
const STYLES_DIR = path.resolve(__dirname, "Styles");

const isProd =
	process.argv.indexOf("--optimize-minimize") > -1 ||
	process.argv.indexOf("-p") > -1;

module.exports = {
	devtool: isProd ? "" : "source-map",
	entry: ["babel-polyfill", `${APP_DIR}/index.jsx`],
	module: {
		rules: [
			{
				test: /\.(png|jpg|gif)$/i,
				use: [
					{
						loader: "url-loader",
						options: {
							limit: 8192,
						},
					},
				],
			},
			{
				test: /\.(js|jsx)$/,
				use: ["babel-loader", "eslint-loader"],
				exclude: /node_modules/,
			},
			{
				test: /\.scss$/,
				include: APP_DIR,
				use: [
					MiniCssExtractPlugin.loader,
					{
						loader: "css-loader",
						options: {
							modules: true,
							localIdentName: "[name]__[local]___[hash:base64:5]",
						},
					},
					"sass-loader",
				],
			},
			{
				test: /\.scss$/,
				include: STYLES_DIR,
				use: [
					MiniCssExtractPlugin.loader,
					{
						loader: "css-loader",
						options: {
							sourceMap: true,
						},
					},
					"sass-loader",
				],
			},
		],
	},
	output: {
		path: BUILD_DIR,
		filename: isProd ? "js/[name].bundle.min.js" : "js/[name].bundle.js",
	},
	plugins: [
		new MiniCssExtractPlugin({
			filename: "css/[name].css",
			chunkFilename: "css/[id].css",
		}),
		new CleanWebpackPlugin(`${BUILD_DIR}/*.*`),
	],
	resolve: {
		extensions: [".js", ".jsx"],
	},
};
