package com.example.wms_mobile;

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
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;

public class SelectWorkingWarehouse extends AppCompatActivity {
    private static final String URL_API_ACCESSWAREHOUSE = "http://10.0.2.2:5269/api/API_Warehouse?";
    private EditText edtWarehouseId;
    private Button btnAccess;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_select_working_warehouse);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        edtWarehouseId = findViewById(R.id.edtWarehouseId);
        btnAccess = findViewById(R.id.btnAccessWarehouse);
        btnAccess.setOnClickListener(v -> {
            handleAccessWarehouse(edtWarehouseId.getText().toString().trim());
        });
    }

    private void handleAccessWarehouse(String warehouseId) {
        if(warehouseId.isEmpty()) {
            Toast.makeText(SelectWorkingWarehouse.this, "Vui lòng nhập đầy đủ thông tin!", Toast.LENGTH_SHORT).show();
            return;
        }
        new Thread(()->{
            try {
                String urlWithParams = URL_API_ACCESSWAREHOUSE + "warehouseId=" + URLEncoder.encode(warehouseId, "UTF-8");
                HttpURLConnection connection = (HttpURLConnection) new URL(urlWithParams).openConnection();
                connection.setRequestMethod("POST");
                connection.setDoOutput(true); // Thiết lập để gửi dữ liệu
                connection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
                try (BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream(), StandardCharsets.UTF_8))) {
                    StringBuilder response = new StringBuilder();
                    String line;
                    while ((line = reader.readLine()) != null) {
                        response.append(line);
                    }
                    JSONObject jsonObject = new JSONObject(response.toString());
                    String result = jsonObject.getString("message");
                    runOnUiThread(()->{
                        if("correct warehouse".equals(result)) {
                            Toast.makeText(SelectWorkingWarehouse.this,"Vào kho thành công", Toast.LENGTH_LONG).show();
                        } else {
                            Toast.makeText(SelectWorkingWarehouse.this,"Mã kho không tồn tại!!!", Toast.LENGTH_LONG).show();
                        }
                    });
                } catch (JSONException e) {
                    throw new RuntimeException(e);
                }
            } catch (UnsupportedEncodingException e) {
                throw new RuntimeException(e);
            } catch (MalformedURLException e) {
                throw new RuntimeException(e);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }).start();
    }
}