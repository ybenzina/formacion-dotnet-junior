DownloadManager skeleton (Semana6)
---------------------------------
- Simple blocking-collection based skeleton: demonstrates producer -> chunk workers -> assemble.
- Tests include a basic run that verifies the manager completes even if some chunk downloads fail.
- NOTE: this is a teaching skeleton; it uses synchronous GetResult in one place for brevity. In production prefer fully async code.
