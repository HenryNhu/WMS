package com.example.wms_mobile;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;

public class MainActivity extends AppCompatActivity {
    private static final String URL_API_LOGIN = "http://10.0.2.2:5269/api/API_Users?";
    private static final String URL_FORGOTEDPASSWORD = "https://www.dienmayxanh.com/";
    private EditText edtUserId, edtPassword;
    private Button btnLogin, btnForgotedPassword;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        edtUserId = findViewById(R.id.edtWarehouseId);
        edtPassword = findViewById(R.id.edtPassword);
        btnLogin = findViewById(R.id.btnAccessWarehouse);
        btnForgotedPassword = findViewById(R.id.btnForgotedPassword);

        btnLogin.setOnClickListener(v -> {
            handleLogin(edtUserId.getText().toString().trim(), edtPassword.getText().toString());
        });
        btnForgotedPassword.setOnClickListener(v -> {
            Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(URL_FORGOTEDPASSWORD));
            startActivity(intent);
        });
    }

private void handleLogin(String userId, String password) {
    if (userId.isEmpty()) {
        Toast.makeText(MainActivity.this, "Vui lòng nhập đầy đủ thông tin!", Toast.LENGTH_SHORT).show();
        return;
    }

    new Thread(() -> {
        try {
            // Đảm bảo URL có query string đúng
            String urlWithParams = URL_API_LOGIN + "UserId=" + URLEncoder.encode(userId, "UTF-8") +
                    "&Password=" + URLEncoder.encode(password, "UTF-8");

            HttpURLConnection connection = (HttpURLConnection) new URL(urlWithParams).openConnection();
            connection.setRequestMethod("POST");
            connection.setDoOutput(true); // Thiết lập để gửi dữ liệu
            connection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            // Gửi yêu cầu
            try (OutputStream outputStream = connection.getOutputStream()) {
                outputStream.flush();

                // Đọc phản hồi từ server
                try (BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream(), StandardCharsets.UTF_8))) {
                    StringBuilder response = new StringBuilder();
                    String line;
                    while ((line = reader.readLine()) != null) {
                        response.append(line);
                    }

                    // Phân tích phản hồi JSON
                    JSONObject jsonObject = new JSONObject(response.toString());
                    String result = jsonObject.getString("message");

                    runOnUiThread(() -> {
                        if ("correct".equals(result)) {
                            Toast.makeText(MainActivity.this, "Đăng nhập thành công", Toast.LENGTH_LONG).show();
                            navToSelectCurrentWarehouse();
                        } else {
                            Toast.makeText(MainActivity.this, "Sai tên đăng nhập hoặc mật khẩu", Toast.LENGTH_LONG).show();
                        }
                    });
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }).start();
}

    private void navToSelectCurrentWarehouse() {
        Intent intent = new Intent(MainActivity.this, SelectWorkingWarehouse.class);
        startActivity(intent);
        finish();
    }

}