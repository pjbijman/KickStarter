const Agent = require("agentkeepalive");

module.exports = {
	'/api': {
		target: "http://localhost:20938",
		secure: false,
		agent: new Agent({
			maxSockets: 100,
			keepAlive: true,
			maxFreeSockets: 10,
			keepAliveMsecs: 100000,
			timeout: 6000000,
			keepAliveTimeout: 90000
		}),
		onProxyRes: proxyRes => {
			const key = "www-authenticate";
			proxyRes.headers[key] = proxyRes.headers[key] &&
				proxyRes.headers[key].split(",");
		}
	}
};
