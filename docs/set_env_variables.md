### How to set environment variables?

To set environment variables, follow steps below for your Operating System (OS). 

Below is an exampe to set the [STATE_API_KEY] environment variable within your local. 

Open your command line terminal and type below command to set environment variables within your local.

**Linux (shell):**

```
export STATE_API_KEY=YOURAPIKEY
```

**Mac OS X (terminal):**

```
export STATE_API_KEY=YOURAPIKEY
```

**Windows (CMD / setx.exe):** 

```
c:\ > setx STATE_API_KEY "YOURAPIKEY"
```

**Windows (PowerShell):** 

```
PS > [System.Environment]::SetEnvironmentVariable("STATE_API_KEY", "YOURAPIKEY", "User"))
```
